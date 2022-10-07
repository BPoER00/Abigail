export default function Custom404() {
  return (
    <div>
      <h2>Error 404</h2>
      <p>Esta página parece ser aun no estar programada</p>
      <p>
        Para crearla, cree una carpeta en <code>/pages/[su-carpeta]/index.jsx</code>
      </p>
      <p>En [su-carpeta] ponga el nombre de la URL.</p>
      <p>
        Por ejemplo para la página home, su url es <code>localhost:3000/home</code>, entonces su carpeta es:
      </p>
      <p>/pages/home/index.jsx</p>
    </div>
  );
}
