let quote = document.getElementById("quote");
let author = document.getElementById("author");
let button = document.getElementById("button");
const url = "https://api.quotable.io/random";

let getQuote = () => {
    fetch(url)
        .then((data) => data.json())
        .then((item) => {
            quote.innerText = item.content;
            author.innerText = item.author;
        });
};

//Event Listener
window.addEventListener("load", getQuote);
button.addEventListener("click", getQuote);