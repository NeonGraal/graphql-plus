using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyOutputTypes(
  ObjectVerifierParams<IGqlpOutputObject, IGqlpOutputField, IGqlpOutputAlternate> verifiers
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

  protected override void UsageField(IGqlpOutputField field, OutputContext context)
  {
    foreach (IGqlpInputParam parameter in field.Params) {
      CheckTypeRef(context, parameter.Type, " Param")
        .CheckModifiers(parameter);
    }

    base.UsageField(field, context);
  }

  protected override OutputContext MakeContext(IGqlpOutputObject usage, IGqlpType[] aliased, ITokenMessages errors)
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
      if (string.IsNullOrWhiteSpace(output.EnumLabel) && context.GetEnumValue(arg.Name, out string? enumType)) {
        output.SetEnumType(enumType);
      }

      if (!string.IsNullOrWhiteSpace(output.EnumLabel)) {
        context.CheckEnumValue("Arg", output);
      }
    }

    base.CheckArgType(error, context, arg);
  }

  internal override void CheckParamConstraint(CheckError error, OutputContext context, IGqlpTypeParam param, IGqlpObjArg arg)
  {
    if (arg is IGqlpOutputArg output) {
      if (string.IsNullOrWhiteSpace(output.EnumLabel)) {
        if (output.EnumType.IsTypeParam) {
          if (context.GetTyped(output.FullType, out IGqlpTypeParam? typeParam)) {
            if (!string.IsNullOrWhiteSpace(typeParam.Constraint)
                && typeParam.Constraint!.Equals(param.Constraint, StringComparison.Ordinal)) {
              return;
            }
          }
        }

        if (context.GetType(param.Constraint, out IGqlpDescribed? constraint)) {
          if (constraint is IGqlpEnum enumType) {
            if (EnumHasLabel(context, enumType, output.EnumType.Name)) {
              output.SetEnumType(enumType.Name);
            }
          } else if (constraint is IGqlpDomain<IGqlpDomainLabel> domType) {
            IGqlpEnum? domEnum = DomainHasLabel(context, domType, output.EnumType.Name);
            if (domEnum is null) {
              error("Domain Enum on  ", $"'{output.EnumType.Name}' not a Value of '{param.Constraint}'");
            } else {
              output.SetEnumType(domEnum.Name);
            }
          }
        }
      }
    }

    base.CheckParamConstraint(error, context, param, arg);
  }

  private IGqlpEnum? DomainHasLabel(OutputContext context, IGqlpDomain<IGqlpDomainLabel> domType, string label)
  {
    foreach (IGqlpDomainLabel item in domType.Items.Where(i => !i.Excludes && (i.EnumItem == label || i.EnumItem == "*"))) {
      if (context.GetTyped(item.EnumType, out IGqlpEnum? enumType)) {
        if (EnumHasLabel(context, enumType, label)) {
          return enumType;
        }
      }
    }

    // Todo: Handle domain parents

    return null;
  }

  [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Todo")]
  internal bool EnumHasLabel(OutputContext context, IGqlpEnum enumType, string label)
  {
    if (enumType.HasValue(label)) {
      return true;
    }

    if (context.GetTyped(enumType.Parent, out IGqlpEnum? parentType)) {
      return EnumHasLabel(context, parentType, label);
    }

    return false;
  }
}
