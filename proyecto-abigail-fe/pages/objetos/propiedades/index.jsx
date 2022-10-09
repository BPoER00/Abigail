import Layout from "components/Layout";

export default function Propiedades({ currentPage = false }) {
  return (
    <Layout currentPage={currentPage}>
      <p>Registrar propiedades</p>
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
