import Layout from "components/Layout";

export default function ControlFisicoPropiedades({ currentPage = false }) {
  return (
    <Layout currentPage={currentPage}>
      <p>ControlFisicoPropiedades</p>
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
