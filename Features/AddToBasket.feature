Feature: AddToBasket
	As a subscribed member I can add product(s) to my cart so that I can build up an online order

Scenario: Adding item to cart changes icon and adds to basket counter
	Given that I am on the inventory shop page with an empty basket,
	When I click “Add to cart” on a product,
	Then it will change the “Add to cart” button to a “Remove” button
	And it creates a counter on the basket icon with the value “1” in it

Scenario: Add item to cart with an item adds to counter
	Given that I am on the inventory shop page with an item in my basket,
	When I click “Add to cart” on a product,
	Then it will increment the basket counter by 1