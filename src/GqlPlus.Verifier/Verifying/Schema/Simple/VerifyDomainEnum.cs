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

    labels.Add(domain, context);

    if (labels.AllExcluded) {
      context.AddError(domain, "Domain Enum", "All labels excluded");
    } else {
      foreach (EnumLabel[] duplicate in labels.DuplicateLabels) {
        string label = duplicate[0].Label;
        string enums = duplicate.Select(x => x.Enum.Name).Joined();
        context.AddError(domain, "Domain Enum", $"'{label}' duplicated from these Enums: {enums}");
      }
    }
  }
}

internal record struct EnumLabel(IGqlpEnum Enum, string Label);

internal class EnumLabels
{
  private readonly List<EnumLabel> _includes = [];
  private readonly List<EnumLabel> _excludes = [];

  internal void Add(IGqlpDomain<IGqlpDomainLabel> domain, EnumContext context)
  {
    if (context.GetTyped(domain.Parent?.Name, out IGqlpDomain<IGqlpDomainLabel>? domainParent)) {
      Add(domainParent, context);
    }

    foreach (IGqlpDomainLabel label in domain.Items) {
      if (string.IsNullOrWhiteSpace(label.EnumType)) {
        AddUntypedLabel(context, label);
      } else if (context.GetTyped(label.EnumType, out IGqlpEnum? theType)) {
        AddTypedLabel(context, label, theType);
      } else {
        context.AddError(label, "Domain Enum", $"'{label.EnumType}' not an Enum type");
      }
    }
  }

  private void AddTypedLabel(EnumContext context, IGqlpDomainLabel label, IGqlpEnum theType)
  {
    if (label.EnumItem == GqlpDomainLabelConstants.All) {
      AddAllLabels(context, label.Excludes, theType);
    } else if (context.GetEnumLabelType(theType, label.EnumItem, out IGqlpEnum? enumType)) {
      Add(label.Excludes, enumType, label.EnumItem);
    } else {
      context.AddError(label, "Domain Enum Label", $"'{label.EnumItem}' not a Label of '{label.EnumType}'");
    }
  }

  private void AddUntypedLabel(EnumContext context, IGqlpDomainLabel label)
  {
    if (context.GetEnumValueType(label.EnumItem, out IGqlpEnum? enumType)) {
      label.SetEnumType(enumType.Name);
      Add(label.Excludes, enumType, label.EnumItem);
    } else {
      context.AddError(label, "Domain Enum Item", $"Enum Label '{label.EnumItem}' not defined");
    }
  }

  private void AddAllLabels(EnumContext context, bool excludes, IGqlpEnum enumType)
  {
    foreach (IGqlpEnumLabel enumLabel in enumType.Items) {
      Add(excludes, enumType, enumLabel.Name);
    }

    if (context.GetTyped(enumType.Parent?.Name, out IGqlpEnum? parentType)) {
      AddAllLabels(context, excludes, parentType);
    }
  }

  internal void Add(bool excluded, IGqlpEnum theEnum, string theLabel)
  {
    IGqlpEnumLabel enumLabel = theEnum.Items.First(m => m.IsNameOrAlias(theLabel));
    if (excluded) {
      _excludes.Add(new(theEnum, enumLabel.Name));
    } else {
      _includes.Add(new(theEnum, enumLabel.Name));
    }
  }

  internal bool AllExcluded
    => _excludes.Count > 0 && !_includes.Except(_excludes).Any();

  internal EnumLabel[][] DuplicateLabels
    => [.. _includes
      .Except(_excludes)
      .GroupBy(m => m.Label)
      .Where(g => g.Count() != 1)
      .Select(g => g.ToArray())];
}
