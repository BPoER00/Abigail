import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";
import Loader from "components/Loader";
import { Line } from "react-chartjs-2";

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, Title, Tooltip, Legend);

const options = {
  responsive: true,
  plugins: {
    legend: {
      position: "top",
    },
    title: {
      display: true,
      text: "Gráfico de ingresos y egresos en los últimos 20 días",
    },
  },
};

function getDateXDaysAgo(numOfDays, date = new Date()) {
  const daysAgo = new Date(date.getTime());

  daysAgo.setDate(date.getDate() - numOfDays);

  return daysAgo.toLocaleString("es").slice(0, 9);
}

const days = [...Array(20).keys()];

const labels = days
  .map((day) => {
    return getDateXDaysAgo(day);
  })
  .reverse();

const data = {
  labels,
  datasets: [
    {
      label: "Egresos",
      data: labels.map(() => Math.floor(Math.random() * 20) + 1),
      borderColor: "rgb(255, 99, 132)",
      backgroundColor: "rgba(255, 99, 132, 0.5)",
    },
    {
      label: "Ingresos",
      data: labels.map(() => Math.floor(Math.random() * 20) + 1),
      borderColor: "rgb(53, 162, 235)",
      backgroundColor: "rgba(53, 162, 235, 0.5)",
    },
  ],
};

export default function ChartHome() {
  return <>{options && data ? <Line options={options} data={data} /> : <Loader />}</>;
}
