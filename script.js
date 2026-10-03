/* ========== DETECÇÃO DE DISPOSITIVO ========== */
const Device = {
  isMobile: () => {
    const ua = /Android|iPhone|iPad|iPod|Opera Mini|IEMobile|WPDesktop/i.test(navigator.userAgent);
    const touch = 'ontouchstart' in window && window.innerWidth < 900;
    return ua || touch;
  },
  isTablet: () => {
    const ua = /iPad|Android(?!.*Mobile)|Tablet/i.test(navigator.userAgent);
    return ua || (window.innerWidth >= 768 && window.innerWidth <= 1024);
  },
  isDesktop: () => !Device.isMobile() && !Device.isTablet(),
  type: () => Device.isMobile() ? 'mobile' : Device.isTablet() ? 'tablet' : 'desktop',
  orientation: () => window.innerWidth > window.innerHeight ? 'landscape' : 'portrait'
};

function applyDeviceMode() {
  const body = document.body;
  const type = Device.type();
  const orient = Device.orientation();
  body.classList.remove('is-mobile', 'is-tablet', 'is-desktop', 'portrait', 'landscape');
  body.classList.add(`is-${type}`, orient);
  body.dataset.device = type;
  if (type === 'mobile') closeSidebar();
}

/* ========== SIDEBAR ========== */
const sidebar = document.getElementById('sidebar');
const overlay = document.getElementById('overlay');
let isMenuOpen = false;

function openSidebar() {
  if (isMenuOpen) return;
  isMenuOpen = true;
  sidebar.classList.add('open');
  overlay.classList.add('open');
  document.body.style.overflow = 'hidden';
}

function closeSidebar() {
  if (!isMenuOpen) return;
  isMenuOpen = false;
  sidebar.classList.remove('open');
  overlay.classList.remove('open');
  document.body.style.overflow = '';
}

function toggleMenu() {
  isMenuOpen ? closeSidebar() : openSidebar();
}

/* ========== NAVEGAÇÃO ========== */
function showPage(pageId, el) {
  document.querySelectorAll('.page').forEach(p => p.classList.remove('active'));
  const target = document.getElementById(pageId);
  if (target) target.classList.add('active');
  document.querySelectorAll('.menu li').forEach(li => li.classList.remove('active'));
  if (el) el.classList.add('active');
  try { localStorage.setItem('playverse_page', pageId); } catch(e) {}
  if (Device.type() !== 'desktop') closeSidebar();
  window.scrollTo({ top: 0, behavior: 'smooth' });
}

/* ========== TEMA ========== */
function applyTheme(theme) {
  if (theme === 'light') document.body.classList.add('light');
  else document.body.classList.remove('light');
  try { localStorage.setItem('playverse_theme', theme); } catch(e) {}
  const meta = document.querySelector('meta[name="theme-color"]');
  if (meta) meta.setAttribute('content', theme === 'light' ? '#ffffff' : '#000000');
}

function toggleTheme() {
  const isLight = document.body.classList.contains('light');
  applyTheme(isLight ? 'dark' : 'light');
}

function initTheme() {
  let saved = null;
  try { saved = localStorage.getItem('playverse_theme'); } catch(e) {}
  if (saved) applyTheme(saved);
  else applyTheme('dark'); // Padrão: preto
}

/* ========== RESTAURA ÚLTIMA PÁGINA ========== */
function restoreLastPage() {
  let saved = null;
  try { saved = localStorage.getItem('playverse_page'); } catch(e) {}
  if (!saved) return;
  const li = document.querySelector(`.menu li[data-page="${saved}"]`);
  if (li) showPage(saved, li);
}

/* ========== EVENTOS ========== */
document.addEventListener('keydown', e => {
  if (e.key === 'Escape' && isMenuOpen) closeSidebar();
});

let resizeTimer;
window.addEventListener('resize', () => {
  clearTimeout(resizeTimer);
  resizeTimer = setTimeout(() => {
    applyDeviceMode();
    if (Device.type() === 'desktop') closeSidebar();
  }, 200);
});

window.addEventListener('orientationchange', () => setTimeout(applyDeviceMode, 300));

/* ========== INIT ========== */
document.addEventListener('DOMContentLoaded', () => {
  applyDeviceMode();
  initTheme();
  restoreLastPage();
});
