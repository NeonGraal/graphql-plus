using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier;

public class SchemaVerifier
{
  private SchemaAst Ast { get; }
  private List<ParseMessage> Errors { get; }

  internal SchemaVerifier(SchemaAst ast)
    => (Ast, Errors) = (ast, new(ast.Errors));

  public static bool Verify(string operation, IParser<SchemaAst> parser, out List<ParseMessage> errors)
  {
    Tokenizer tokens = new(operation);
    var parse = parser.Parse(tokens);

    if (parse is IResultError<SchemaAst> error) {
      errors = new List<ParseMessage> { error.Message };
      return false;
    }

    var verifier = new SchemaVerifier(parse.Optional()!);
    var result = verifier.Verify();

    errors = verifier.Errors;
    return result;
  }

  private bool Verify()
  {
    Ast.Errors = Errors.ToArray();

    return Ast.Result == ParseResultKind.Success && !Ast.Errors.Any();
  }
}
