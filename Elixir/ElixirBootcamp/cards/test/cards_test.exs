defmodule CardsTest do
  use ExUnit.Case
  doctest Cards

  test "ceate_deck makes 20 cards" do
    deck_length = length(Cards.create_deck)

    assert deck_length == 20
  end
end
