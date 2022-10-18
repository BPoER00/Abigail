import Layout from "components/Layout";

import styles from "./styles.module.css";

const DATA_EXAMPLE = [
  {
    ingreso: true,
    dpi: "1234567890123",
    hora: "16:00",
    fecha: "25/09/2022",
    modalidad: "Vehículo",
    tipo_de_persona: "Vecino",
    destino: "1111",
  },
  {
    ingreso: false,
    dpi: "1234567890155",
    hora: "17:00",
    fecha: "25/09/2022",
    modalidad: "Vehículo",
    tipo_de_persona: "Visitante",
    destino: "-",
  },
  {
    ingreso: true,
    dpi: "1234567890122",
    hora: "16:00",
    fecha: "25/09/2022",
    modalidad: "Vehículo",
    tipo_de_persona: "Vecino",
    destino: "2321",
  },
  {
    ingreso: false,
    dpi: "1234567890151",
    hora: "17:00",
    fecha: "25/09/2022",
    modalidad: "Vehículo",
    tipo_de_persona: "Visitante",
    destino: "-",
  },
];

export default function IngresosEgresosCondominio({ currentPage = false }) {
  return (
    <Layout currentPage={currentPage}>
      <h2>Reportes</h2>
      <h3>Reporte de ingresos y egresos</h3>
      <table className={styles.table}>
        <thead>
          <tr className={styles.trHeader}>
            <th>Ingreso/egreso</th>
            <th>DPI</th>
            <th>Hora</th>
            <th>Fecha</th>
            <th>Modalidad</th>
            <th>Tipo de persona</th>
            <th>Destino</th>
          </tr>
        </thead>
        <tbody>
          {DATA_EXAMPLE.map((data, index) => (
            <tr key={index} className={`${styles.tr} ${data.ingreso && styles.trIngreso}`}>
              <td>{data.ingreso ? "Ingreso" : "Egreso"}</td>
              <td>{data.dpi}</td>
              <td>{data.hora}</td>
              <td>{data.fecha}</td>
              <td>{data.modalidad}</td>
              <td>{data.tipo_de_persona}</td>
              <td>{data.destino}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
