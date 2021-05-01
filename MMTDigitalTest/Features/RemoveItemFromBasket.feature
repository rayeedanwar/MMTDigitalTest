Feature: RemoveItemFromBasket
	As a subscribed member I can remove product(s) from my cart so that I can check out with a cart only containing the items I want

	Background: 
	Given that I am on the login page
	And I click “Log in” with standard_user and secret_sauce

Scenario: Removing item changes icon to Add to cart
	Given I select 3 products
	And I want to remove any product
	And the button for the product shows "REMOVE"
	When I click the "REMOVE" button
	Then the button for the product shows "ADD TO CART" 
	And it will reduce the basket counter icon by 1

Scenario: Option to remove available for every product
	Given I select 3 products
	When I am on the basket page
	Then I can see options to remove each product present from the basket

Scenario: Removing item reduces basket count
	Given I select 3 products
	And I want to remove any product
	When I click the "REMOVE" button
	Then it will remove the item from the basket
	And it will reduce the basket counter icon by 1

Scenario: Removing single item removes basket counter
	Given I select 1 product
	And I want to remove any product
	When I click the "REMOVE" button
	Then it will remove the item from the basket
	And it will remove the basket counter icon
