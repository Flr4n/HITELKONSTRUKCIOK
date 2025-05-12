document.getElementById('kalkulatorForm').addEventListener('submit', async (e) => {
    e.preventDefault();
    const osszeg = document.getElementById('osszeg').value;
    const kamat = document.getElementById('kamat').value;

    const response = await fetch(`http://localhost:5000/api/ajanlatok?osszeg=${osszeg}&kamat=${kamat}`);
    const data = await response.json();

    const container = document.getElementById('ajanlatok');
    container.innerHTML = '';
});