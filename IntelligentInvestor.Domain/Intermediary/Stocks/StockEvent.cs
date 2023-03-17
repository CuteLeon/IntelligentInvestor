using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Intermediary.Abstractions.Domain;

namespace IntelligentInvestor.Domain.Intermediary.Stocks;

public record StockEvent(Stock Stock, StockEventTypes EventType) : IIntermediaryEvent;
