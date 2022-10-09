import { ArrowNarrowRight } from "components/Icons";
import Layout from "components/Layout";
import LinkButton from "components/LinkButton";
import Image from "next/image";

import styles from "./styles.module.css";

export default function Home({ currentPage = false }) {
  return (
    <Layout currentPage={currentPage}>
      <div>
        <h1 className={styles.title}>Buen día</h1>
        <div className={styles.firstSection}>
          <article className={`${styles.card} ${styles.quejasContainer}`}>
            <div className={styles.imageContainer}>
              <Image src="/icons/flag.svg" width="72" height="72" alt="Estado de quejas" />
              <span className={styles.result}>54</span>
            </div>
            <span className={styles.cardTitle}>Quejas pendientes</span>
            <div className={styles.btn}>
              <LinkButton href="/reportes/estado-quejas">
                Revisar
                <ArrowNarrowRight />
              </LinkButton>
            </div>
          </article>
          <article className={`${styles.card} ${styles.cuentasPorCobrarContainer}`}>
            <header className={styles.cuentaHeader}>
              <span className={styles.cardTitle}>Cuentas por cobrar</span>
              <LinkButton href="/cuentas-por-cobrar">Ver listado</LinkButton>
            </header>
            <span className={styles.result}>30</span>
            <div>Aquí iría la tabla</div>
          </article>
        </div>
        <article className={`${styles.card} ${styles.graph}`}>
          <header className={styles.headerGraph}>
            <span className={styles.cardTitle}>Entradas y salidas de los últimos días</span>
            <LinkButton href="/reportes/ingresos-egresos-condominio">
              Ver reporte
              <ArrowNarrowRight />
            </LinkButton>
          </header>
          <span>Aquí iría la gráfica</span>
        </article>
      </div>
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
