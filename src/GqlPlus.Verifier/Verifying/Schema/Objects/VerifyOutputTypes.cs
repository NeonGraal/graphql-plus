using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyOutputTypes(
  ObjectVerifierParams<IGqlpOutputObject, IGqlpOutputField, IGqlpOutputAlternate, IGqlpOutputArg> verifiers
) : AstObjectVerifier<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputArg, IGqlpOutputField, IGqlpOutputAlternate, OutputContext>(verifiers)
{
  protected override void UsageValue(IGqlpOutputObject usage, OutputContext context)
  {
    IEnumerable<IGqlpOutputField> enumFields = usage.ObjFields
      .Where(f => !string.IsNullOrWhiteSpace(f.EnumLabel));

    foreach (IGqlpOutputField? enumField in enumFields) {
      if (string.IsNullOrWhiteSpace(enumField.EnumType.Name)) {
        if (context.GetEnumValue(enumField.EnumLabel!, out string? enumType)) {
          enumField.SetEnumType(enumType);
        } else {
          context.AddError(enumField, "Output Field Enum", $"Enum Value '{enumField.EnumLabel}' not defined");
        }
      } else {
        context.CheckEnumValue("Field", enumField);
      }
    }

    base.UsageValue(usage, context);
  }

  protected override void UsageFields(IGqlpOutputObject usage, OutputContext context)
  {
    base.UsageFields(usage, context);

    foreach (IGqlpOutputField field in usage.ObjFields) {
      foreach (IGqlpInputParam parameter in field.Params) {
        CheckTypeRef(context, parameter.Type, " Param");
        context.CheckModifiers(parameter);
      }
    }
  }

  protected override OutputContext MakeContext(IGqlpOutputObject usage, IGqlpType[] aliased, IMessages errors)
  {
    Map<IGqlpDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IGqlpDescribed)p.First()))
      .Concat(usage.TypeParams.Select(p => (Id: "$" + p.Name, Type: (IGqlpDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors, aliased.MakeEnumValues());
  }

  internal override void CheckArgType(CheckError error, OutputContext context, IGqlpObjArg arg)
  {
    if (arg is IGqlpOutputArg output) {
      if (string.IsNullOrWhiteSpace(output.EnumLabel)
        && !context.GetType(arg.Name, out IGqlpDescribed? type)
        && context.GetEnumValue(arg.Name, out string? enumType)) {
        output.SetEnumType(enumType);
      }

      if (!string.IsNullOrWhiteSpace(output.EnumLabel)) {
        context.CheckEnumValue("Arg", output);
      }
    }

    base.CheckArgType(error, context, arg);
  }
}
