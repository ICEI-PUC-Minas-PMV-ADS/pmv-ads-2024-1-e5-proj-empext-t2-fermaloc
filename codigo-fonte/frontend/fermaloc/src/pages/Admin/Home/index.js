import React from "react";
import useAuthentication from "../../../hooks/useAuthentication";

export default function HomeAdmin() {
  const { authenticated } = useAuthentication();
  return <>{authenticated && <div>Login feito com sucesso!</div>}</>;
}
