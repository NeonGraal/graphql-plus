using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyDomainEnum(
  IMerge<IGqlpDomainLabel> items
) : AstDomainVerifier<IGqlpDomainLabel>(items)
{
  protected override void VerifyDomain(IGqlpDomain<IGqlpDomainLabel> domain, EnumContext context)
  {
    EnumLabels labels = new();

    foreach (IGqlpDomainLabel label in domain.Items) {
      if (string.IsNullOrWhiteSpace(label.EnumType)) {
        if (context.GetEnumValue(label.EnumItem, out string? enumType)) {
          label.SetEnumType(enumType);
          if (context.GetTyped(label.EnumType, out IGqlpEnum? theType)) {
            labels.Add(label.Excludes, theType, label.EnumItem);
          }
        } else {
          context.AddError(label, "Domain Enum Item", $"Enum Label '{label.EnumItem}' not defined");
        }
      } else if (context.GetTyped(label.EnumType, out IGqlpEnum? theType)) {
        if (label.EnumItem == "*") {
          AddAllLabels(labels, context, label.Excludes, theType);
        } else if (context.GetEnumValueType(theType, label.EnumItem, out IGqlpEnum? enumType)) {
          labels.Add(label.Excludes, enumType, label.EnumItem);
        } else {
          context.AddError(label, "Domain Enum Label", $"'{label.EnumItem}' not a Label of '{label.EnumType}'");
        }
      } else {
        context.AddError(label, "Domain Enum", $"'{label.EnumType}' not an Enum type");
      }
    }

    foreach (EnumLabel[] duplicate in labels.DuplicateLabels()) {
      string label = duplicate[0].Label;
      string enums = duplicate.Select(x => x.Enum.Name).Joined();
      context.AddError(domain, "Domain Enum", $"'{label}' duplicated from these Enums: {enums}");
    }
  }

  private static void AddAllLabels(EnumLabels labels, EnumContext context, bool excludes, IGqlpEnum enumType)
  {
    foreach (IGqlpEnumLabel enumLabel in enumType.Items) {
      labels.Add(excludes, enumType, enumLabel.Name);
    }

    if (context.GetTyped(enumType.Parent?.Name, out IGqlpEnum? parentType)) {
      AddAllLabels(labels, context, excludes, parentType);
    }
  }
}

internal record struct EnumLabel(IGqlpEnum Enum, string Label);

internal class EnumLabels
{
  private readonly List<EnumLabel> _includes = [];
  private readonly List<EnumLabel> _excludes = [];

  internal void Add(bool excluded, IGqlpEnum theEnum, string theLabel)
  {
    IGqlpEnumLabel enumLabel = theEnum.Items.First(m => m.IsNameOrAlias(theLabel));
    if (excluded) {
      _excludes.Add(new(theEnum, enumLabel.Name));
    } else {
      _includes.Add(new(theEnum, enumLabel.Name));
    }
  }

  internal EnumLabel[][] DuplicateLabels()
  {
    IEnumerable<IGrouping<string, EnumLabel>> allLabels = _includes
      .Except(_excludes)
      .GroupBy(m => m.Label);

    return [.. allLabels
      .Where(g => g.Count() != 1)
      .Select(g => g.ToArray())];
  }
}
