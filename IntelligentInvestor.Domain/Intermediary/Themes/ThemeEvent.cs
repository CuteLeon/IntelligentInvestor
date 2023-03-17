using IntelligentInvestor.Domain.Themes;
using IntelligentInvestor.Intermediary.Abstractions.Domain;

namespace IntelligentInvestor.Domain.Intermediary.Themes;

public record ThemeEvent(UIThemes UITheme) : IIntermediaryEvent;
