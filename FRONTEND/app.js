document.getElementById('kalkulatorForm').addEventListener('submit', async (e) => {
    e.preventDefault();

    const osszeg = document.getElementById('osszeg').value;
    const kamat = document.getElementById('kamat').value;

    const response = await fetch('http://localhost:5153/api/ajanlatok?osszeg=' + osszeg + '&kamat=' + kamat, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });    

    if (response.ok) {
        const data = await response.json();
        const container = document.getElementById('ajanlatok');
        container.innerHTML = '';

        data.forEach(ajanlat => {
            let szin = 'bg-success text-white';
            if (ajanlat.HaviTorleszto > 600000) szin = 'bg-danger text-white';
            else if (ajanlat.HaviTorleszto > 250000) szin = 'bg-warning';

            const card = `
                <div class="col-md-4 mb-4">
                    <div class="card ${szin}">
                        <div class="card-body">
                            <h5 class="card-title">${ajanlat.Ev} év</h5>
                            <p class="card-text">Havi törlesztés: ${ajanlat.HaviTorleszto.toLocaleString()} Ft</p>
                            <p class="card-text">Összesen visszafizetendő: ${ajanlat.Visszafizetendo.toLocaleString()} Ft</p>
                        </div>
                    </div>
                </div>
            `;
            container.innerHTML += card;
        });
    } else {
        alert("Hiba történt az adatok lekérésekor.");
    }
});
