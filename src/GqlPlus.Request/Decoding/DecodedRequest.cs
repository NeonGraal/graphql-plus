using GqlPlus.Ast.Operation;

namespace GqlPlus.Decoding;

public record DecodedRequest(
    string? Category,
    string? Operation,
    IAstOperation? ParsedOperation,
    Structured Parameters,
    IMessages Errors);
