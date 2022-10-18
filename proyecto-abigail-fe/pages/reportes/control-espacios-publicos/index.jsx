import Layout from "components/Layout";

export default function ControlEspacioPublicos({ currentPage = false }) {
  return (
    <Layout currentPage={currentPage}>
      <p>ControlEspacioPublicos</p>
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
