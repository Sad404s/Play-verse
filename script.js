/* ============================================
   RELÓGIO EM TEMPO REAL
   ============================================ */

function updateClock() {
  const el = document.getElementById('clock-time');
  if (!el) return;

  const now = new Date();

  const pad = (n) => String(n).padStart(2, '0');

  const h = pad(now.getHours());
  const m = pad(now.getMinutes());
  const s = pad(now.getSeconds());

  el.textContent = `${h}:${m}:${s}`;
}

// Inicia o relógio (a cada 1 segundo)
function initClock() {
  updateClock();
  setInterval(updateClock, 1000);
}

// Adiciona no DOMContentLoaded junto com o resto
window.addEventListener('DOMContentLoaded', () => {
  if (typeof initClock === 'function') initClock();
});

/* ============================================
   GARANTE QUE AS NOVAS PÁGINAS FUNCIONEM
   ============================================ */

// Se seu showPage() já está no script.js, não precisa mexer.
// Só verifica se as novas seções têm os IDs certos:
// - #contribuidores
// - #misterio
// (já estão no HTML que mandei)
