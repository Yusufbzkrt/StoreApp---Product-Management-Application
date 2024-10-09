<script>
	document.addEventListener("DOMContentLoaded", function () {
		var cards = document.querySelectorAll('.card');
	var maxHeight = 0;

	// Tüm kartların maksimum yüksekliğini bul
	cards.forEach(function (card) {
			var cardHeight = card.offsetHeight;
			if (cardHeight > maxHeight) {
		maxHeight = cardHeight;
			}
		});

	// Tüm kartların yüksekliğini maksimum yüksekliğe ayarla
	cards.forEach(function (card) {
		card.style.height = maxHeight + 'px';
		});
	});
</script>