describe ('References', () => {
    before(() => {
        cy.setCookie('jwt', 'Not authenticated')
        cy.visit('/login')
        cy.get('input[name=Username').type("AustinB")
        cy.get('input[name=Password').type("BallState#Student@21")

        cy.contains('Gain Access').click().then(() => {
            cy.wait(5000)
        })
    })

    beforeEach(() => {
        Cypress.Cookies.preserveOnce('jwt', 'username')
    })

    it('Tests that Cypress works', () => {
        cy.visit('/references')
        expect(true).to.equal(true)
    })

    it('Checks that Account page can be clicked and accessed', () => {
        cy.get('.collapsed').contains('Account').click()
        cy.contains('/Accounts').click()
        cy.url().should('equal', 'http://localhost:8080/references/1')
    })

    it('Tests the Get account information endpoint with the AccountNumberParam in the console', () => {
        cy.get('#AccountNumber').type("00555")
        cy.get('#execute-button').click()
        cy.get('#console-response').should('not.have.value', '{\n\tResponse will show up here\n}')
    })

    it('Goes into edit mode', () => {
        cy.get('#edit-mode-button').click()
        cy.get('#save-edit').should('be.visible')
    })

    it('Opens edit history modal', () => {
        cy.get('#edit-overview').click()
        cy.get('#PageEdits-modal').should('be.visible')
        cy.get('#PageEdits-modal').get(".close").click()
    })

    it('Checks that Account group page can be clicked and accessed and the endpoint can be tested', () => {
        cy.get('.collapsed').contains('AccountGroup').click()
        cy.contains('/AccountGroups/{accountGroupId}').first().click()
        cy.get('#accountGroupId').type("1")
        cy.get('#execute-button').click()
        cy.get('#console-response').should('not.have.value', '{\n\tResponse will show up here\n}')
    })
})