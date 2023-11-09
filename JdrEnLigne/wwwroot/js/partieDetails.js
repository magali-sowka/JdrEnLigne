const links = Array.from(document.getElementsByClassName("lien"));
const details = Array.from(document.getElementsByClassName("details"));
function active(url) {
	var div = url.split('#')[1] ?? "partieDetails";
	details.forEach(d => d.hidden = true);
	document.getElementById(div).hidden = false;
	links.forEach(l => l.classList.remove("active"));
	links.forEach(l => {
		if (l.href == url || l.href == url + '#partieDetails') {
			l.classList.add("active");
		}
		else {
			l.classList.remove("active");
		}
	});
}

active(window.location.href);
links.forEach(link => link.addEventListener("click", function () {
	active(link.href);
}));