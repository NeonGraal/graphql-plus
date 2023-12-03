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
    var allTypes = new Declarations<AstType>(Ast.Declarations);
    var outputTypes = new Declarations<OutputAst>(Ast.Declarations);
    var categories = new Declarations<CategoryAst>(Ast.Declarations);

    VerifyCategories(categories, outputTypes.Ids);
    VerifyTypes(allTypes);

    Ast.Errors = Errors.ToArray();

    return Ast.Result == ParseResultKind.Success && !Ast.Errors.Any();
  }

  private void Error<T>(T value, string error)
    where T : AstBase
    => Errors.Add(value.Error(error));

  private void VerifyCategories(Declarations<CategoryAst> categories, HashSet<string> outputTypes)
  {
    foreach (var group in categories.ById) {
      if (group.Count() > 1) {
        Error(group.Last(), $"Invalid Categories. Multiple Categories named '{group.Key}' found.");
        continue;
      }

      var category = group.First();

      if (!outputTypes.Contains(category.Output)) {
        Error(category, $"Invalid Category. Output '{category.Output}' not defined.");
        continue;
      }
    }
  }

  private void VerifyTypes(Declarations<AstType> allTypes)
  {
    foreach (var group in allTypes.ById) {
      var set = group.GroupBy(t => t.GetType());
      if (set.Count() > 1) {
        Error(group.Last(), $"Invalid Types. Multiple Types named '{group.Key}' found.");
        continue;
      }
    }
  }
}

internal readonly struct Declarations<T>
    where T : AstAliased
{
  internal readonly T[] All;
  internal readonly ILookup<string, T> ById;
  internal readonly HashSet<string> Ids;

  internal Declarations(IEnumerable<object> types)
  {
    All = types.OfType<T>().ToArray();
    var names = All
      .Select(l => l.Name).Distinct().ToHashSet();

    Ids = All.SelectMany(i => i.Aliases).Union(names).Distinct()
      .ToHashSet();

    ById = All.SelectMany(t => t.Aliases.Select(a => (Id: a, Item: t)))
      .Where(p => !names.Contains(p.Id))
      .Concat(All.Select(t => (Id: t.Name, Item: t)))
      .ToLookup(p => p.Id, p => p.Item);
    ;
  }
}
