import styles from "./styles.module.css";

const DATA_EXAMPLE = [
  {
    id: 1,
    vecino: "Luis Renato Granados",
    cuotas: 17,
    proximo_cobro: "25/09/2022",
  },
  {
    id: 2,
    vecino: "Danilo Rosal",
    cuotas: 12,
    proximo_cobro: "23/09/2022",
  },
];

export default function CuentasPorCobrarTable() {
  return (
    <table className={styles.table}>
      <thead>
        <tr className={styles.trHeader}>
          <th>Vecino</th>
          <th>Cuotas</th>
          <th>Próximo cobro</th>
        </tr>
      </thead>
      <tbody>
        {DATA_EXAMPLE.map((row) => (
          <tr key={row.id} className={styles.tr}>
            <td>{row.vecino.length > 20 ? row.vecino.slice(0, 15) + "..." : row.vecino}</td>
            <td>{row.cuotas}</td>
            <td>{row.proximo_cobro}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
