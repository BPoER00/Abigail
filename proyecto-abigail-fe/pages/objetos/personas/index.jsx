import Layout from "components/Layout";

export default function Personas({ currentPage = false }) {
  return (
    <Layout currentPage={currentPage}>
      <h2>Registrar personas</h2>
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
