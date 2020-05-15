const express = require('express')
const bodyParser = require('body-parser')
const axios = require('axios')

const app = express()

app.post('/events', async (req, resp) => {
    const { type, data } = req.body
    
    if(type === 'CommentCreated'){
        const status = data.content.incudes('orange') ? 'rejected' : 'approved'

        await axios.post('http://localhost:4005/events', {
            type: 'CommentModerated',
            data: {
                id: data.id,
                postId: data.postId,
                status,
                content: data.content
            }
        })
    }

    resp.send({})
})

app.listen(4003, () => {
	console.log('Listinin on 4003')
})
