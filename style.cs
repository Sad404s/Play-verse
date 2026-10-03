* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: 'Segoe UI', sans-serif;
}

body {
  background: #1e1f22;
  color: #ffffff;
  min-height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 20px;
  overflow: hidden;
}

/* fundo animado sutil */
body::before {
  content: "";
  position: fixed;
  top: -50%;
  left: -50%;
  width: 200%;
  height: 200%;
  background: radial-gradient(circle at center, #5865F2 0%, transparent 40%);
  opacity: 0.08;
  animation: pulse 6s ease-in-out infinite;
  pointer-events: none;
}

@keyframes pulse {
  0%, 100% { transform: scale(1); opacity: 0.08; }
  50% { transform: scale(1.1); opacity: 0.15; }
}

.container {
  text-align: center;
  max-width: 500px;
  width: 100%;
  position: relative;
  z-index: 1;
}

.logo {
  display: flex;
  justify-content: center;
  margin-bottom: 30px;
  animation: float 3s ease-in-out infinite;
}

@keyframes float {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-10px); }
}

h1 {
  font-size: 48px;
  font-weight: 800;
  letter-spacing: 8px;
  color: #ffffff;
  margin-bottom: 20px;
  text-shadow: 0 0 30px rgba(88, 101, 242, 0.6);
}

.divider {
  width: 60px;
  height: 3px;
  background: #5865F2;
  margin: 0 auto 25px;
  border-radius: 2px;
}

p {
  color: #b5bac1;
  font-size: 16px;
  margin-bottom: 35px;
  line-height: 1.5;
}

.loader {
  display: flex;
  justify-content: center;
  gap: 10px;
  margin-bottom: 35px;
}

.loader span {
  width: 12px;
  height: 12px;
  background: #5865F2;
  border-radius: 50%;
  animation: bounce 1.4s ease-in-out infinite;
}

.loader span:nth-child(2) { animation-delay: 0.2s; }
.loader span:nth-child(3) { animation-delay: 0.4s; }

@keyframes bounce {
  0%, 80%, 100% { transform: scale(0.6); opacity: 0.4; }
  40% { transform: scale(1); opacity: 1; }
}

.status {
  display: inline-flex;
  align-items: center;
  gap: 8px;
  background: #2b2d31;
  padding: 8px 16px;
  border-radius: 20px;
  font-size: 13px;
  color: #b5bac1;
  margin-bottom: 35px;
}

.status svg {
  animation: blink 2s ease-in-out infinite;
}

@keyframes blink {
  0%, 100% { opacity: 1; }
  50% { opacity: 0.3; }
}

.socials {
  display: flex;
  justify-content: center;
  gap: 20px;
}

.socials a {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 44px;
  height: 44px;
  background: #2b2d31;
  border-radius: 50%;
  transition: all 0.25s ease;
}

.socials a:hover {
  background: #5865F2;
  transform: translateY(-4px);
}

.socials a:hover svg path {
  fill: #ffffff;
  transition: fill 0.25s ease;
}

/* Responsivo */
@media (max-width: 500px) {
  h1 { font-size: 32px; letter-spacing: 5px; }
  .logo svg { width: 90px; height: 68px; }
  p { font-size: 14px; }
}
