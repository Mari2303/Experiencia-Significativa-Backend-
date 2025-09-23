using Entity.Dtos.ModuleOperation.CreateEvaluation;
using Entity.Models.ModuleOperation;
using System;
using System.Collections.Generic;
using System.Linq;

public class EvaluationBuilder
{
    private readonly Evaluation _evaluation;
    private readonly List<EvaluationCriteria> _evaluationCriterias = new();
    private int _totalScore;

    public EvaluationBuilder(EvaluationRegisterDTO dto)
    {
        _evaluation = new Evaluation
        {
            TypeEvaluation = dto.TypeEvaluation,
            AccompanimentRole = dto.AccompanimentRole,
            Comments = dto.Comments,
            UserId = dto.UserId,
            ExperienceId = dto.ExperienceId,
            State = true,
            CreatedAt = DateTime.UtcNow
        };
    }

    // Solo guardamos los datos de los criterios sin asignar EvaluationId
    public EvaluationBuilder AddCriteriaScores(IEnumerable<EvaluationCriteriaInputDTO> criteriaScores)
    {
        foreach (var c in criteriaScores)
        {
            int scoreSum = c.Scores.Sum(); // Suma los 3 números de cada criterio
            _totalScore += scoreSum;

            var evalCriteria = new EvaluationCriteria
            {
                CriteriaId = c.CriteriaId,
                Score = scoreSum,
                State = true,
                CreatedAt = DateTime.UtcNow
            };

            _evaluationCriterias.Add(evalCriteria);
        }
        return this;
    }

    
    public (Evaluation Evaluation, List<EvaluationCriteria> Criteria) Build()
    {
        _evaluation.EvaluationResult = CalcularResultadoFinal(_totalScore);
        return (_evaluation, _evaluationCriterias);
    }

    private string CalcularResultadoFinal(int totalScore) =>
        totalScore <= 45 ? "Naciente" :
        totalScore <= 79 ? "Creciente" : "Inspiradora";
}


