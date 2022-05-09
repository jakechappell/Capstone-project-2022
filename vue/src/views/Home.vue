<template>
  <div id="home-page" class="text-center">
    <div class="flex align-middle"  :style="main">
        <div class="py-48 ml-28">
            <h1 class="text-left font-bold text-5xl text-white">Custom solutions at your fingertips</h1>
            <p class="ml-1 text-left text-lg text-white">Connect, simplify, and automate your work with the Cheetah API</p>
            <div class="flex justify-left space-x-6 pt-2 ml-1">
                <a class="text-base text-white no-underline border-2 border-blue-700 hover:border-blue-400 rounded-md px-2 py-1" href="#features">Features</a>
                <a class="text-base text-white no-underline border-2 border-blue-700 hover:border-blue-400 rounded-md px-2 py-1" href="#usages">Usages</a>
                <a class="text-base text-white no-underline border-2 border-blue-700 hover:border-blue-400 rounded-md px-2 py-1" href="https://www.trustasc.com">Visit Accutech</a>
            </div>
        </div>
    </div>
    <section class="py-36 px-32 bg-gray-200">
        <div class="grid grid-cols-3">
            <div class="col-span-1">
                <div class="flex justify-center align-center">
                    <svg xmlns="http://www.w3.org/2000/svg" width="70" height="70" fill="blue" class="bi bi-window-desktop" viewBox="0 0 16 16">
                        <path d="M3.5 11a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h9a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5h-9Z"/>
                        <path d="M2.375 1A2.366 2.366 0 0 0 0 3.357v9.286A2.366 2.366 0 0 0 2.375 15h11.25A2.366 2.366 0 0 0 16 12.643V3.357A2.366 2.366 0 0 0 13.625 1H2.375ZM1 3.357C1 2.612 1.611 2 2.375 2h11.25C14.389 2 15 2.612 15 3.357V4H1v-.643ZM1 5h14v7.643c0 .745-.611 1.357-1.375 1.357H2.375A1.366 1.366 0 0 1 1 12.643V5Z"/>
                    </svg>
                </div><br>
                <p class="text-3xl font-bold text-accuBlue">Custom Integration</p>
                <p class="text-lg px-10">The Cheetah API allow for any custom integration your business needs.</p>
            </div>
            <div class="col-span-1">
                <div class="flex justify-center align-center">
                    <svg xmlns="http://www.w3.org/2000/svg" width="70" height="70" fill="blue" class="bi bi-layers" viewBox="0 0 16 16">
                        <path d="M8.235 1.559a.5.5 0 0 0-.47 0l-7.5 4a.5.5 0 0 0 0 .882L3.188 8 .264 9.559a.5.5 0 0 0 0 .882l7.5 4a.5.5 0 0 0 .47 0l7.5-4a.5.5 0 0 0 0-.882L12.813 8l2.922-1.559a.5.5 0 0 0 0-.882l-7.5-4zm3.515 7.008L14.438 10 8 13.433 1.562 10 4.25 8.567l3.515 1.874a.5.5 0 0 0 .47 0l3.515-1.874zM8 9.433 1.562 6 8 2.567 14.438 6 8 9.433z"/>
                    </svg>
                </div><br>
                <p class="text-3xl font-bold text-accuBlue">Robust</p>
                <p class="text-lg px-10">Our ever-expanding API library will cater to any needs.</p>
            </div>
            <div class="col-span-1">
                <div class="flex justify-center align-center">
                    <svg xmlns="http://www.w3.org/2000/svg" width="70" height="70" fill="blue" class="bi bi-check-circle" viewBox="0 0 16 16">
                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
                        <path d="M10.97 4.97a.235.235 0 0 0-.02.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-1.071-1.05z"/>
                    </svg>
                </div><br>
                <p class="text-3xl font-bold text-accuBlue">Easy to Use</p>
                <p class="text-lg px-10">Ready to use with your own data, with documentation & client support.</p>
            </div>
        </div>
    </section>
    <section id="usages">
        <div class="grid grid-cols-2 grid-rows-3">
            <div class="col-span-1 row-span-1 flex items-center justify-center bg-gray-100">
                <div>
                    <p class="text-4xl font-bold px-10 text-accuBlue">Create Powerful Integrations</p>
                    <p class="text-xl px-20">Your data shouldn't be locked away. With the Cheetah API, you can build custom integrations to fit your business needs</p>
                </div>
            </div>
            <div class="col-span-1 row-span-1">
                <img class="h-full w-full" src="@/assets/bg-showcase-1.jpg">
            </div>
            <div class="col-span-1 row-span-1">
                <img class="h-full w-full" src="@/assets/bg-showcase-2.jpg">
            </div>
            <div class="col-span-1 row-span-1 flex items-center justify-center bg-gray-100">
                <div>
                    <p class="text-4xl font-bold px-10 text-accuBlue">Develop unique end-client experiences</p>
                    <p class="text-xl px-20">The robustness of the Cheetah API allows for not only business integrations, but end-client experiences as well.</p>
                </div>
            </div>
            <div class="col-span-1 row-span-1 flex items-center justify-center bg-gray-100">
                <div>
                    <p class="text-4xl font-bold px-10 text-accuBlue">Easy to Use & Customize</p>
                    <p class="text-xl px-20">Our comprehensive API documentation provides insight for new and experienced developers.</p>
                </div>
            </div>
            <div class="col-span-1 row-span-1">
                <img class="h-full w-full" src="@/assets/bg-showcase-3.jpg">
            </div>
        </div>
    </section>
    <section>
        <div id="features" class="flex justify-center w-full pt-10 pb-12 text-center">
            <div class="w-96">
                <h3 class="text-2xl font-bold border-b border-gray-600 pb-4 text-gray-600">Features</h3>
            </div>
        </div>
        <div id="row-one" class="px-32 pb-10">
            <div class="grid grid-cols-2 space-x-20">
                <div id="accounts" class="col-span-1 px-7 py-8 text-left">
                    <h1 class="font-bold text-accuBlue">Accounts</h1>
                    <p class="text-lg pr-10">Create & manage all accounts in one space. Read account balances, transaction history, holdings, fees, statements, and relationships.</p>
                </div>
                <div id="approvals" class="col-span-1 px-7 py-8 text-left">
                    <h1 class="font-bold text-accuBlue">Approvals</h1>
                    <p class="text-lg">Keep up-to-date with administrative tasks such as approving trades, deposits, and withdraws.&nbsp;</p>
                </div>
            </div>
        </div>
        <div id="row-two" class="px-32 pb-10">
            <div class="grid grid-cols-2 space-x-20">
                <div id="investment-modeling" class="col-span-1 px-7 py-8 text-left">
                    <h1 class="font-bold text-accuBlue">Assets</h1>
                    <p class="text-lg pr-10">Pull & Update asset data including pricing, interest rates, dividends, and holdings.</p>
                </div>
                <div id="transactions" class="col-span-1 px-7 py-8 text-left">
                    <h1 class="font-bold text-accuBlue">Data Integration</h1>
                    <p class="text-lg pr-10">Seamlessly transfer data to & from third party applications.</p>
                </div>
            </div>
        </div>
        <div id="row-three" class="px-32 pb-10">
            <div class="grid grid-cols-2 space-x-20">
                <div id="files" class="col-span-1 px-7 py-8 text-left">
                    <h1 class="font-bold text-accuBlue">Files</h1>
                    <p class="text-lg pr-10">View download attached reports, statements, and other documents.</p>
                </div>
                <div id="fees" class="col-span-1 px-7 py-8 text-left">
                    <h1 class="font-bold text-accuBlue">Fees</h1>
                    <p class="text-lg pr-10">Create, view, and manage account fees.</p>
                </div>
            </div>
        </div>
        <div id="row-three" class="px-32 pb-10">
            <div class="grid grid-cols-2 space-x-20">
                <div id="investment-modeling" class="col-span-1 px-7 py-8 text-left">
                    <h1 class="font-bold text-accuBlue">Investment Modeling</h1>
                    <p class="text-lg pr-10">Create, view, and manage investment models and apply directly to accounts.</p>
                </div>
                <div id="transactions" class="col-span-1 px-7 py-8 text-left">
                    <h1 class="font-bold text-accuBlue">Transactions</h1>
                    <p class="text-lg pr-10">View, save, and process transaction batches and scheduled transactions automatically.</p>
                </div>
            </div>
        </div>
    </section>
  </div>
</template>

<script>
export default {
    data() {
        return {
            main: {
                backgroundImage: `url(${require('@/assets/main.jpg')})`,
                backgroundSize: 'cover'
            }
        }
    }
}
</script>


<style lang="less" scoped>

</style>