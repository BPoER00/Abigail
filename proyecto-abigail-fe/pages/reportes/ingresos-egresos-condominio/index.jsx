import Layout from "components/Layout";

export default function IngresosEgresosCondominio({ currentPage = false }) {
  return (
    <Layout currentPage={currentPage}>
      <div>IngresosEgresosCondominio</div>
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
