import Layout from "components/Layout";

export default function EstadoMorosiadCuentasPorCobrar({ currentPage = false }) {
  return (
    <Layout currentPage={currentPage}>
      <p>EstadoMorosiadCuentasPorCobrar</p>
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
