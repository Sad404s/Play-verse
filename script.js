'use strict';

const Device = {
  isMobile() {
    const ua = /Android|iPhone|iPad|iPod|Opera Mini|IEMobile|WPDesktop/i.test(navigator.userAgent);
    const touch = 'ontouchstart' in window && window.innerWidth < 900;
    return ua || touch;
  },
  isTablet() {
    const ua = /iPad|Android(?!.*Mobile)|Tablet/i.test(navigator.userAgent);
    return ua || (window.innerWidth >= 768 && window.innerWidth <= 1024);
  },
  isDesktop() { return !Device.isMobile() && !Device.isTablet(); },
  type() {
    if (Device.isMobile()) return 'mobile';
    if (Device.isTablet()) return 'tablet';
    return 'desktop';
  },
  orientation() { return window.innerWidth > window.innerHeight ? 'landscape' : 'portrait'; }
};

function applyDeviceMode() {
  const b = document.body;
  const type = Device.type();
  const orient = Device.orientation();
  b.classList.remove('is-mobile','is-tablet','is-desktop','portrait','landscape');
  b.classList.add('is-' + type, orient);
  b.dataset.device = type;
  if (type === 'mobile' && isMenuOpen) closeSidebar();
}

let isMenuOpen = false;
let sidebar, overlay;

function initSidebar() {
  sidebar = document.getElementById('sidebar');
  overlay = document.getElementById('overlay');
}

function openSidebar() {
  if (isMenuOpen || !sidebar) return;
  isMenuOpen = true;
  sidebar.classList.add('open');
  overlay.classList.add('open');
  document.body.style.overflow = 'hidden';
}

function closeSidebar() {
  if (!isMenuOpen || !sidebar) return;
  isMenuOpen = false;
  sidebar.classList.remove('open');
  overlay.classList.remove('open');
  document.body.style.overflow = '';
}

function toggleMenu() { isMenuOpen ? closeSidebar() : openSidebar(); }

const PAGES = ['home','sobre','regras','contribuidores','misterio'];
const STORAGE_PAGE = 'playverse_page';

function showPage(pageId, el) {
  if (!PAGES.includes(pageId)) return;
  document.querySelectorAll('.page').forEach(p => p.classList.remove('active'));
  const t = document.getElementById(pageId);
  if (t) t.classList.add('active');
  document.querySelectorAll('.menu li').forEach(li => li.classList.remove('active'));
  if (el) el.classList.add('active');
  else {
    const li = document.querySelector('.menu li[data-page="' + pageId + '"]');
    if (li) li.classList.add('active');
  }
  try { localStorage.setItem(STORAGE_PAGE, pageId); } catch (e) {}
  if (Device.type() !== 'desktop') closeSidebar();
  window.scrollTo({ top: 0, behavior: 'smooth' });
}

function restoreLastPage() {
  let s = null;
  try { s = localStorage.getItem(STORAGE_PAGE); } catch (e) {}
  if (s && PAGES.includes(s)) showPage(s);
}

const STORAGE_THEME = 'playverse_theme';

function applyTheme(theme) {
  if (theme === 'light') document.body.classList.add('light');
  else document.body.classList.remove('light');
  try { localStorage.setItem(STORAGE_THEME, theme); } catch (e) {}
  const m = document.querySelector('meta[name="theme-color"]');
  if (m) m.setAttribute('content', theme === 'light' ? '#f5f5f5' : '#000000');
}

function toggleTheme() {
  const isLight = document.body.classList.contains('light');
  applyTheme(isLight ? 'dark' : 'light');
}

function initTheme() {
  let s = null;
  try { s = localStorage.getItem(STORAGE_THEME); } catch (e) {}
  if (s) applyTheme(s);
  else {
    const prefers = window.matchMedia('(prefers-color-scheme: light)').matches;
    applyTheme(prefers ? 'light' : 'dark');
  }
}

let clockInterval = null;

function updateClock() {
  const el = document.getElementById('clock-time');
  if (!el) return;
  const now = new Date();
  const pad = n => String(n).padStart(2, '0');
  el.textContent = pad(now.getHours()) + ':' + pad(now.getMinutes()) + ':' + pad(now.getSeconds());
}

function initClock() {
  updateClock();
  if (clockInterval) clearInterval(clockInterval);
  clockInterval = setInterval(updateClock, 1000);
}

function initKeyboard() {
  document.addEventListener('keydown', e => {
    if (e.key === 'Escape' && isMenuOpen) { closeSidebar(); return; }
    const tag = document.activeElement?.tagName;
    if (tag === 'INPUT' || tag === 'TEXTAREA') return;
    const shortcuts = { '1':'home','2':'sobre','3':'regras','4':'contribuidores','5':'misterio' };
    if (shortcuts[e.key]) showPage(shortcuts[e.key]);
  });
}

let resizeTimer = null;

function handleResize() {
  clearTimeout(resizeTimer);
  resizeTimer = setTimeout(() => {
    applyDeviceMode();
    if (Device.type() === 'desktop' && isMenuOpen) closeSidebar();
  }, 200);
}

function handleOrientation() { setTimeout(applyDeviceMode, 300); }

function init() {
  initSidebar();
  applyDeviceMode();
  initTheme();
  initClock();
  initKeyboard();
  restoreLastPage();
  window.addEventListener('resize', handleResize);
  window.addEventListener('orientationchange', handleOrientation);
  console.log('[Play Verse] OK - ' + Device.type());
}

if (document.readyState === 'loading') {
  document.addEventListener('DOMContentLoaded', init);
} else {
  init();
}
