describe ('Workflows Tests', () => {
    before(() => {
        cy.setCookie('jwt', 'No calls')
        cy.setCookie('username', 'CypressTest')

    })

    beforeEach(() => {
        Cypress.Cookies.preserveOnce('jwt', 'username')
    })

    it('Tests that Cypress works', () => {
        cy.visit('/workflows').then(() => {
            cy.wait(5000)
        })

        expect(true).to.equal(true)
    })

    it('Checks that the Creating Cheetah API Keys dropdown loads', () => {
        cy.contains("Creating Cheetah API Keys").should('be.visible')
    })

    it('Checks that the Creating Cheetah API Keys dropdown shows info on click', () => {
        cy.contains("Creating Cheetah API Keys").click()
        cy.get('.tutorial').should('be.visible')
        cy.contains("Creating Cheetah API Keys").click()
    })

    it('Checks that the Generating a Cheetah API Token dropdown loads', () => {
        cy.contains("Generating a Cheetah API Token").should('be.visible')
    })

    it('Checks that the Generating a Cheetah API Token dropdown shows info on click', () => {
        cy.contains("Generating a Cheetah API Token").click()
        cy.get('.tutorial').should('be.visible')
        cy.contains("Generating a Cheetah API Token").click()
    })

    it('Checks that the Using the Cheetah API Docs test console dropdown loads', () => {
        cy.contains("Using the Cheetah API Docs test console").should('be.visible')
    })

    it('Checks that the Creating Cheetah API Keys dropdown shows info on click', () => {
        cy.contains("Using the Cheetah API Docs test console").click()
        cy.get('.tutorial').should('be.visible')
        cy.contains("Using the Cheetah API Docs test console").click()
    })

})