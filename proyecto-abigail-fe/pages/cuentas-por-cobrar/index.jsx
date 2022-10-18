import CuentasPorCobrarTable from "components/CuentasPorCobrarTable";
import { PlusIcon } from "components/Icons";
import Layout from "components/Layout";
import LinkButton from "components/LinkButton";

import styles from "./styles.module.css";

export default function CuentasPorCobrar({ currentPage = false }) {
  return (
    <Layout currentPage={currentPage}>
      <header className={styles.header}>
        <h2>Listado de vecinos por cobrar</h2>
        <LinkButton href="/cuentas-por-cobrar/registrar">
          <PlusIcon />
          Nueva cuota
        </LinkButton>
      </header>
      <CuentasPorCobrarTable />
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
