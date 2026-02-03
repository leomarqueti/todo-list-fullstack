import React from "react";

export default function TarefaCompleta({
  tarefa,
  carregando,
  aoVoltar,
  aoExcluir,
}) {
  if (carregando) return <li>Foleando o caderno...</li>;
  if (!tarefa) return null;

  return (
    <React.Fragment>
      <li>
        <button onClick={aoVoltar} className="botao-voltar">
          ↶ Voltar para o índice
        </button>
      </li>
      <li></li>
      <li>
        <strong style={{ fontSize: "1.2em", textDecoration: "underline" }}>
          {tarefa.name}
        </strong>
      </li>
      {tarefa.description && (
        <li style={{ color: "#555" }}>↳ {tarefa.description}</li>
      )}
      {tarefa.priority && (
        <li style={{ color: "#d9534f" }}>★ Prioridade: {tarefa.priority}</li>
      )}
      {tarefa.dueDate && (
        <li style={{ color: "#2c3e50" }}>
          📅 Data: {new Date(tarefa.dueDate).toLocaleDateString()}
        </li>
      )}
      <li>Status: {tarefa.status === "2" ? "Pendente" : "Concluída"}</li>

      <li></li>
      <li>
        <button onClick={() => aoExcluir(tarefa.id)} className="botao-excluir">
          ❌ Arrancar folha (Excluir)
        </button>
      </li>
    </React.Fragment>
  );
}
