const express = require('express')
const bodyParser = require('body-parser')
const { randomBytes } = require('crypto')
const cors = require('cors')
const axios = require('axios')

const app = express()
app.use(bodyParser.json())
app.use(cors())

const commentsByPostId = {}

app.get('/posts/:id/comments', (req, resp) => {
	resp.send(commentsByPostId[req.params.id] || [])
})

app.post('/posts/:id/comments', async (req, resp) => {
	const commentId = randomBytes(4).toString('hex')
	const { content } = req.body

	let postId = req.params.id

	let comments = commentsByPostId[postId] || []

	comments.push({
		id: commentId,
		content,
		status: 'pending',
	})

	commentsByPostId[postId] = comments

	await axios.post('http://localhost:4005/events', {
		type: 'CommentCreated',
		data: {
			id: commentId,
			content,
			postId: req.params.id,
			status: 'pending'
		},
	})

	resp.status(201).send(comments)
})

app.post('/events', (req, res) => {
	console.log('Received Event:', req.body.type)

	res.send({})
})

app.listen(4001, () => {
	console.log('Listening on 4001')
})
