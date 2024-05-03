using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;
using GqlPlus.Token;

namespace GqlPlus.Verification.Schema.Objects;

internal class VerifyInputTypes(
  IVerifyAliased<InputDeclAst> aliased,
  IMerge<InputFieldAst> fields,
  IMerge<AstAlternate<InputBaseAst>> mergeAlternates,
  ILoggerFactory logger
) : AstObjectVerifier<InputDeclAst, InputFieldAst, InputBaseAst, UsageContext>(aliased, fields, mergeAlternates, logger)
{
  protected override UsageContext MakeContext(InputDeclAst usage, AstType[] aliased, ITokenMessages errors)
  {
    Map<AstDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (AstDescribed)p.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (AstDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors);
  }

  protected override void UsageField(InputFieldAst field, UsageContext context)
  {
    base.UsageField(field, context);

    if (field.Default?.Value?.EnumValue == "Null.null" && !(field.Modifiers.LastOrDefault()?.Kind == ModifierKind.Optional)) {
      context.AddError(field, "Input Field Default", $"'null' default requires Optional type, not '{field.ModifiedType}'");
    }
  }
}
