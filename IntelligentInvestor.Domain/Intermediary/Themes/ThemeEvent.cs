using IntelligentInvestor.Domain.Themes;
using IntelligentInvestor.Intermediary.Domain;

namespace IntelligentInvestor.Domain.Intermediary.Themes;

public record ThemeEvent(UIThemes UITheme) : IIntermediaryEvent;
