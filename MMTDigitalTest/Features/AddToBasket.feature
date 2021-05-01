Feature: AddToBasket
	As a subscribed member I can add product(s) to my cart so that I can build up an online order

	Background: 
	Given that I am on the login page
	And I click “Log in” with standard_user and secret_sauce
	# better to have username and password elsewhere to avoid needing to retype it

Scenario: Adding item to cart changes icon and adds to basket counter
	Given I want to select any product
	And the button for the product shows "ADD TO CART"
	When I click the "ADD TO CART" button
	Then the button for the product shows "REMOVE" 
	And it creates a counter on the basket icon with the value "1" in it

Scenario: Add item to cart with an item adds to counter
	Given I click “Add to cart” on the Sauce Labs Bolt T-Shirt product
	And it creates a counter on the basket icon with the value "1" in it
	When I click “Add to cart” on the Sauce Labs Bike Light product
	Then it creates a counter on the basket icon with the value "2" in it
