import Layout from "components/Layout";

export default function CuentasPorCobrar({ currentPage = false }) {
  return (
    <Layout currentPage={currentPage}>
      <h1>
        hola Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quidem debitis necessitatibus eos, vero
        tempora nostrum tenetur maxime nam accusantium, molestias sed. Incidunt, ullam! Nemo aliquid deserunt ad quam
        eligendi.
      </h1>
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
