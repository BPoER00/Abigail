import Layout from "components/Layout";

export default function Home({ currentPage = false }) {
  return (
    <Layout currentPage={currentPage}>
      <section>
        <p>Pongan su contenido</p>
      </section>
    </Layout>
  );
}

// SSR y ISR
// Docs: https://nextjs.org/docs/basic-features/pages

// Explicación:
// SSR - Server Side Rendering
//    - Se ejecuta en el servidor
//    - Se ejecuta cada vez que se recarga la página

// ISR - Incremental Static Regeneration
//    - Se ejecuta en el servidor
//    - Se ejecuta cada vez que se hace una Build de la aplicación
//    - Al ser ISR, podemos darle un tiempo para que se vuelva a construir la aplicación automáticamente

// En este caso, estaremos usando SSR
// Pero en un caso más real, sería mejor ISR aquí por temas de costos económicos

// Resumen:
// El SSR es el mejor para páginas dinámicas.
// El ISR es el mejor para páginas que tu ya sabes de antemano que ya existen.

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
