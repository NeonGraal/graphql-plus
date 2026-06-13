using GqlPlus.Ast.Operation;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Request.Reading;
using GqlPlus.Result;

namespace GqlPlus.Request.Decoding;

public class RequestInputDecoder(IParserRepository parsers) : IRequestInputDecoder
{
  private readonly ParserOne<IAstOperation> _parser = parsers.ParserFor<IAstOperation>();

  public DecodedRequest Decode(string input)
  {
    if (input is null) {
      throw new ArgumentNullException(nameof(input));
    }

    GqReqInput reqInput = GqReqReader.Read(input);
    Structured parameters = ParameterBuilder.Build(reqInput.Parameters);
    IMessages errors = Messages.New;

    OperationContext tokens = new(reqInput.Definition);
    IResult<IAstOperation> result = _parser.Parse(tokens, "Operation");

    IAstOperation? operation = null;

    result.Required(op => {
      operation = op;
      errors = errors.Add(op.Errors);
    });
    result.WithMessage(msg => errors = errors.Add(msg));

    string? category = reqInput.Category ?? operation?.Category;
    return new DecodedRequest(category, reqInput.Operation, operation, parameters, errors);
  }
}
