
//Добавление книги
const addBookButton = document.querySelector("#addBookButton");
const addBookWindow = document.querySelector("#addBookWindow");
const closeBookWindow = document.querySelector("#closeBookWindow");

addBookButton.addEventListener("click", () => {
	addBookWindow.showModal();
});

closeBookWindow.addEventListener("click", () => {
	addBookWindow.close();
});

//Редактирование книги
const editBookButtons = document.querySelectorAll(".edit-book-button");
const editBookWindow = document.querySelector("#editBookWindow");
const closeEditBookWindow = document.querySelector("#closeEditBookWindow");

editBookButtons.forEach(button => button.addEventListener("click", () => {
	document.querySelector("#editTitle").value = button.dataset.title;
	document.querySelector("#editGenre").value = button.dataset.genre;
	document.querySelector("#editId").value = button.dataset.id;
	document.querySelector("#editYear").value = button.dataset.year;
	document.querySelector("#editAuthor").value = button.dataset.author;


	editBookWindow.showModal();
}));

closeEditBookWindow.addEventListener("click", () => { editBookWindow.close(); });

//Поиск книги
const searchBookButton = document.querySelector("#searchBookButton");
const searchBookWindow = document.querySelector("#searchBookWindow");
const closeSearchBookWindow = document.querySelector("#closeSearchBookWindow");

searchBookButton.addEventListener("click", () => {
	searchBookWindow.showModal();
});

closeSearchBookWindow.addEventListener("click", () => {
	searchBookWindow.close();
});