const addBookButton = document.querySelector("#addBookButton");
const addBookWindow = document.querySelector("#addBookWindow");
const closeBookWindow = document.querySelector("#closeBookWindow");

addBookButton.addEventListener("click", () => {
	addBookWindow.showModal();
});

closeBookWindow.addEventListener("click", () => {
	addBookWindow.close();
});