* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: 'Segoe UI', sans-serif;
}

:root {
  --bg: #313338;
  --bg-dark: #1e1f22;
  --bg-card: #2b2d31;
  --blue: #5865F2;
  --blue-hover: #4752c4;
  --text: #ffffff;
  --text-muted: #b5bac1;
  --green: #23A55A;
  --yellow: #F0B232;
  --red: #F23F43;
  --border: rgba(255,255,255,0.06);
}

/* TEMA CLARO */
body.light {
  --bg: #f2f3f5;
  --bg-dark: #ffffff;
  --bg-card: #ffffff;
  --text: #060607;
  --text-muted: #4e5058;
  --border: rgba(0,0,0,0.08);
}

html, body {
  overflow-x: hidden;
  width: 100%;
}

body {
  background: var(--bg);
  color: var(--text);
  min-height: 100vh;
  transition: background 0.3s, color 0.3s;
}

/* ===== TOPBAR ===== */
.topbar {
  position: fixed;
  top: 0; left: 0; right: 0;
  height: 60px;
  background: var(--bg-dark);
  display: flex;
  align-items: center;
  padding: 0 18px;
  gap: 16px;
  z-index: 100;
  box-shadow: 0 2px 10px rgba(0,0,0,0.15);
  border-bottom: 1px solid var(--border);
}

.menu-btn, .theme-btn {
  background: transparent;
  border: none;
  cursor: pointer;
  padding: 8px;
  border-radius: 8px;
  display: flex;
  align-items: center;
  color: var(--text);
  transition: background 0.2s;
}

.menu-btn:hover, .theme-btn:hover {
  background: rgba(128,128,128,0.15);
}

.theme-btn {
  margin-left: auto;
}

.theme-btn .icon-sun { display: none; }
body.light .theme-btn .icon-moon { display: none; }
body.light .theme-btn .icon-sun { display: block; }

.topbar-logo {
  display: flex;
  align-items: center;
  gap: 10px;
  font-weight: 700;
  font-size: 18px;
  letter-spacing: 1px;
}

/* ===== SIDEBAR ===== */
.sidebar {
  position: fixed;
  top: 0; left: 0;
  width: 280px;
  height: 100vh;
  background: var(--bg-dark);
  transform: translateX(-100%);
  transition: transform 0.3s ease;
  z-index: 200;
  display: flex;
  flex-direction: column;
  box-shadow: 4px 0 20px rgba(0,0,0,0.3);
  border-right: 1px solid var(--border);
}

.sidebar.open {
  transform: translateX(0);
}

.sidebar-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 20px;
  border-bottom: 1px solid var(--border);
  font-weight: 700;
  letter-spacing: 1px;
  color: var(--text-muted);
}

.close-btn {
  background: transparent;
  border: none;
  cursor: pointer;
  padding: 6px;
  border-radius: 6px;
  display: flex;
  color: var(--text-muted);
  transition: background 0.2s;
}

.close-btn:hover {
  background: rgba(128,128,128,0.15);
}

.menu {
  list-style: none;
  padding: 15px 10px;
  flex: 1;
}

.menu li {
  display: flex;
  align-items: center;
  gap: 14px;
  padding: 12px 16px;
  margin-bottom: 4px;
  border-radius: 8px;
  cursor: pointer;
  color: var(--text-muted);
  transition: all 0.2s;
  font-size: 15px;
  font-weight: 500;
}

.menu li:hover {
  background: rgba(128,128,128,0.15);
  color: var(--text);
}

.menu li.active {
  background: var(--blue);
  color: #fff;
}

.sidebar-footer {
  padding: 16px 20px;
  border-top: 1px solid var(--border);
}

.status {
  display: flex;
  align-items: center;
  gap: 8px;
  font-size: 13px;
  color: var(--text-muted);
}

/* ===== OVERLAY ===== */
.overlay {
  position: fixed;
  inset: 0;
  background: rgba(0,0,0,0.6);
  opacity: 0;
  visibility: hidden;
  transition: opacity 0.3s ease;
  z-index: 150;
}

.overlay.open {
  opacity: 1;
  visibility: visible;
}

/* ===== CONTENT ===== */
.content {
  padding: 100px 30px 60px;
  max-width: 1000px;
  margin: 0 auto;
}

.page {
  display: none;
  animation: fadeIn 0.35s ease;
}

.page.active {
  display: block;
}

@keyframes fadeIn {
  from { opacity: 0; transform: translateY(15px); }
  to { opacity: 1; transform: translateY(0); }
}

/* HOME */
.hero {
  text-align: center;
  padding: 40px 20px 60px;
}

.hero-logo {
  margin-bottom: 25px;
  display: flex;
  justify-content: center;
}

.hero h1 {
  font-size: 44px;
  margin-bottom: 15px;
  background: linear-gradient(135deg, var(--text), var(--blue));
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
}

.hero p {
  color: var(--text-muted);
  font-size: 17px;
  margin-bottom: 30px;
  max-width: 500px;
  margin-left: auto;
  margin-right: auto;
}

.cta {
  background: var(--blue);
  color: #fff;
  border: none;
  padding: 14px 36px;
  border-radius: 10px;
  font-size: 16px;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.2s;
}

.cta:hover {
  background: var(--blue-hover);
  transform: translateY(-2px);
  box-shadow: 0 8px 20px rgba(88,101,242,0.4);
}

.features {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(220px, 1fr));
  gap: 20px;
  margin-top: 30px;
}

.feature {
  background: var(--bg-card);
  padding: 25px;
  border-radius: 12px;
  text-align: center;
  transition: transform 0.2s, box-shadow 0.2s;
  border: 1px solid var(--border);
}

.feature:hover {
  transform: translateY(-4px);
  box-shadow: 0 10px 24px rgba(0,0,0,0.2);
}

.feature svg { margin-bottom: 12px; }

.feature h3 {
  font-size: 18px;
  margin-bottom: 8px;
  color: var(--text);
}

.feature p {
  color: var(--text-muted);
  font-size: 14px;
  line-height: 1.5;
}

/* SOBRE */
.page h1 {
  font-size: 32px;
  margin-bottom: 25px;
  color: var(--text);
}

.card-text {
  background: var(--bg-card);
  padding: 30px;
  border-radius: 12px;
  line-height: 1.7;
  border: 1px solid var(--border);
}

.card-text p {
  color: var(--text-muted);
  margin-bottom: 15px;
}

.card-text strong { color: var(--blue); }

.list { list-style: none; margin: 20px 0; }

.list li {
  display: flex;
  align-items: center;
  gap: 10px;
  padding: 8px 0;
  color: var(--text-muted);
}

.bullet {
  width: 8px;
  height: 8px;
  background: var(--blue);
  border-radius: 50%;
  flex-shrink: 0;
}

/* REGRAS */
.sub {
  color: var(--text-muted);
  margin-bottom: 25px;
}

.rule {
  display: flex;
  gap: 18px;
  background: var(--bg-card);
  padding: 22px;
  border-radius: 12px;
  margin-bottom: 15px;
  border-left: 4px solid var(--blue);
  transition: transform 0.2s;
  border-top: 1px solid var(--border);
  border-right: 1px solid var(--border);
  border-bottom: 1px solid var(--border);
}

.rule:hover { transform: translateX(5px); }

.rule.warn {
  border-left-color: var(--yellow);
  background: linear-gradient(90deg, rgba(240,178,50,0.08), var(--bg-card));
}

.rule-icon { flex-shrink: 0; padding-top: 2px; }

.rule-body h3 {
  font-size: 17px;
  margin-bottom: 8px;
  color: var(--text);
}

.rule-body p {
  color: var(--text-muted);
  font-size: 14px;
  line-height: 1.6;
}

.rule-body strong { color: var(--red); }

/* ==========================================
   MODOS DE DISPOSITIVO
   ========================================== */

body.is-mobile .content { padding: 80px 16px 40px; }
body.is-mobile .hero { padding: 20px 10px 40px; }
body.is-mobile .hero h1 { font-size: 28px; line-height: 1.2; }
body.is-mobile .hero p { font-size: 14px; }
body.is-mobile .cta { width: 100%; padding: 14px 20px; }
body.is-mobile .features { grid-template-columns: 1fr; gap: 14px; }
body.is-mobile .feature { padding: 18px; }
body.is-mobile .sidebar { width: 85vw; max-width: 300px; }
body.is-mobile .page h1 { font-size: 22px; }
body.is-mobile .rule { flex-direction: column; gap: 12px; padding: 18px; }
body.is-mobile .card-text { padding: 20px; }

body.is-tablet .content { padding: 90px 24px 50px; max-width: 720px; }
body.is-tablet .hero h1 { font-size: 34px; }
body.is-tablet .features { grid-template-columns: repeat(2, 1fr); }
body.is-tablet .sidebar { width: 300px; }

body.is-desktop .content { padding: 100px 40px 60px; max-width: 1000px; }
body.is-desktop .features { grid-template-columns: repeat(3, 1fr); }

/* ==========================================
   ORIENTAÇÃO
   ========================================== */

body.landscape.is-mobile .content { padding: 70px 24px 30px; }
body.landscape.is-mobile .hero { padding: 10px; }
body.landscape.is-mobile .hero h1 { font-size: 24px; }
body.landscape.is-mobile .features { grid-template-columns: repeat(2, 1fr); }

/* ==========================================
   CORREÇÕES ANTI-BUG
   ========================================== */

body.is-mobile * {
  -webkit-tap-highlight-color: transparent;
}

@supports (height: 100dvh) {
  body.is-mobile .sidebar { height: 100dvh; }
}

@media (hover: none) {
  .feature:hover, .rule:hover, .cta:hover {
    transform: none;
    box-shadow: none;
  }
}

@media (max-width: 480px) {
  .hero h1 { font-size: 24px; }
  .topbar-logo span { font-size: 15px; }
}

@media (min-width: 1400px) {
  .content { max-width: 1100px; }
}

/* Safe area (iPhone notch) */
@supports (padding: env(safe-area-inset-top)) {
  .topbar {
    padding-top: env(safe-area-inset-top);
    height: calc(60px + env(safe-area-inset-top));
  }
  body.is-mobile .content {
    padding-top: calc(80px + env(safe-area-inset-top));
  }
}
