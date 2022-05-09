describe ('Base test Login', () => {
    it('Tests that Cypress works', () => {
    cy.visit('/login')
    expect(true).to.equal(true)
    })
})

describe ('RA modal loading', () => {
    it('Tests that Request Access modal opens after clicking', () => {
        cy.visit('/login')
        cy.contains("Request Access").click()
        cy.get("#modal-1").should('be.visible')
    })
})

describe ('RA modal close with X', () => {
    it('Tests that Request Access modal closes when pressing X button', () => {
        cy.get("#modal-1").get(".close").click()
        cy.get("#modal-1").should('not.exist')
    })
})

describe ('Request Access walkthrough', () => {
    it('Tests Request Access functionality', () => {
        cy.contains("Request Access").click()

        cy.get('input[name=firstName]').type("First")
        cy.get('input[name=lastName]').type("Last")
        cy.get('input[name=emailAddress]').type("email@email.com")
        cy.get('input[name=company]').type("Company Name")
        cy.get('#dev').check()
        cy.get('#reasonInput').type("Reason input")
        cy.contains("Submit Form").click()

        cy.get("#modal-1").should('not.exist') //WAY TO TEST THAT THE SCRIPT GOES THROUGH?
    })
})



describe ('Login walkthrough', () => {
    it('Tests Login functionality', () => {

        cy.get('input[name=Username').type("AustinB")
        cy.get('input[name=Password').type("BallState#Student@21")  //WAY TO OBFUSCATE THIS??

        cy.contains('Gain Access').click()
        
        cy.url().should('equal', 'http://localhost:8080/references')
        Cypress.Cookies.preserveOnce('jwt', 'username')
    })
})

describe ('Login redirect', () => {
    it('Tests that accessing login page while logged in redirects to references page', () => {
        cy.visit('/login')
        cy.url().should('equal', 'http://localhost:8080/references')
    })
})