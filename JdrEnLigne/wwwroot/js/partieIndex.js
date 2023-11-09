const select = document.getElementById("pageSize");
select.addEventListener("change", function () {
	window.location.href = select.value;
});