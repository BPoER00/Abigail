import Image from "next/image";

export default function Logo({ width = 180, height = 138 }) {
  return <Image src={"/images/Logo.png"} width={width} height={height} alt="Logo Abigail" />;
}
