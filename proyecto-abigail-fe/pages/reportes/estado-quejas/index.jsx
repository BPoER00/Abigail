import Layout from "components/Layout";

export default function EstadoQuejas({ currentPage }) {
  return (
    <Layout currentPage={currentPage}>
      <div>EstadoQuejas</div>
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
