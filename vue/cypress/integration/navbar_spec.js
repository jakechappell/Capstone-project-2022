describe ('Base test Home', () => {             //HOME
    it('Tests that Cypress works', () => {
    cy.visit('/')
    expect(true).to.equal(true)
    })
})

describe ('Data loader button test', () => {
    it('Tests that data loader button appears on home page', () => {
    cy.contains("Run Data Loading").should('be.visible')
    })
})

describe ('Login button test', () => {
    it('Tests that login button sends to login', () => {
    cy.contains("Login").click() 
    cy.url().should('equal', 'http://localhost:8080/login')
    })
})

describe ('Home button test', () => {
    it('Tests that home button sends to home', () => {
    cy.contains("Home").click()
    cy.url().should('equal', 'http://localhost:8080/')
    })
})

describe ('Menu button test 1', () => {
    it('Tests the dropdown menu sending to references', () => {
        cy.setCookie('jwt', 'No calls')
        cy.setCookie('username', 'CypressTest')
        cy.visit('/')
        
        cy.get('#nav-dropdown').click()
        cy.contains('References').click()
        
        Cypress.Cookies.preserveOnce('jwt', 'username')
        cy.url().should('include', '/references')
    })
})

describe ('Menu button test 2', () => {
    it('Tests the dropdown menu sending to workflows', () => {
        cy.get('#nav-dropdown').click()
        cy.contains('Workflows/Tutorials').click()
        
        cy.url().should('include', '/workflows')
    })
})

describe ('Data loader button test', () => {                                    //LOGIN
    it('Tests that data loader button does not appear on login page', () => {
        cy.visit('/login')
        cy.contains("Run Data Loading").should('not.exist')
    })
})

describe ('Login button test', () => {
    it('Tests that login button does not exist on login page', () => {
        cy.get('#nav-link').contains("Login").should('not.exist');
    })
})

describe ('Home button test', () => {
    it('Tests that home button sends to home', () => {
    cy.contains("Home").click()
    cy.url().should('equal', 'http://localhost:8080/')
    })
})

describe ('Data loader button test', () => {
    it('Tests that data loader button does not appear on page', () => {         //WORKFLOWS
        cy.setCookie('jwt', 'No calls')
        cy.setCookie('username', 'CypressTest')
        cy.visit('/workflows')
        cy.contains("Run Data Loading").should('not.exist')
        Cypress.Cookies.preserveOnce('jwt', 'username')
    })
})

describe ('Login button test', () => {
    it('Tests that login button does not exist on page (logged in)', () => {
        cy.get('#nav-link').contains("Login").should('not.exist');
        Cypress.Cookies.preserveOnce('jwt', 'username')
    })
})

describe ('Home button test', () => {
    it('Tests that home button sends to home', () => {
        cy.contains("Home").click()
        cy.url().should('equal', 'http://localhost:8080/')
    })
})

describe ('Logout test', () => {
    it('Tests that logout button sends to login page', () => {
        cy.setCookie('jwt', 'No calls')
        cy.setCookie('username', 'CypressTest')
        cy.get('#nav-dropdown').click()
        cy.contains('Logout').click()
        cy.url().should('equal', 'http://localhost:8080/login')
    })

    it('Tests that cookie is removed', () => {
        cy.getCookie('jwt').should('not.exist')
    })
})