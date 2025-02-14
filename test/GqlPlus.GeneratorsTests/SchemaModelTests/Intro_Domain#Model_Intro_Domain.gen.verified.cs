//HintName: Model_Intro_Domain.gen.cs
// Generated from Intro_Domain.graphql+
/*
enum _DomainKind { Boolean Enum Number String }
output _TypeDomain {
    | _BaseDomain<_DomainKind.Boolean _DomainTrueFalse _DomainItemTrueFalse>
    | _BaseDomain<_DomainKind.Enum _DomainMember _DomainItemMember>
    | _BaseDomain<_DomainKind.Number _DomainRange _DomainItemRange>
    | _BaseDomain<_DomainKind.String _DomainRegex _DomainItemRegex>
    }
output _DomainRef<$kind> {
    : _TypeRef<_TypeKind.Domain>
        domainKind: $kind
    }
output _BaseDomain<$domain $item $domainItem> {
    : _ParentType<_TypeKind.Domain $item  $domainItem>
        domain: $domain
    }
dual _BaseDomainItem {
        exclude: Boolean
    }
output _DomainItem<$item> {
    : $item
        domain: _Identifier
    }
output _DomainValue<$kind $value> {
    : _DomainRef<$kind>
        value: $value
    }
dual _DomainTrueFalse {
    : _BaseDomainItem
        value: Boolean
    }
output _DomainItemTrueFalse {
    : _DomainItem<_DomainTrueFalse>
    }
output _DomainMember {
    : _BaseDomainItem
        value: _EnumValue
    }
output _DomainItemMember {
    : _DomainItem<_DomainMember>
    }
dual _DomainRange {
    : _BaseDomainItem
        lower: Number?
        upper: Number?
    }
output _DomainItemRange {
    : _DomainItem<_DomainRange>
    }
dual _DomainRegex {
    : _BaseDomainItem
        pattern: String
    }
output _DomainItemRegex {
    : _DomainItem<_DomainRegex>
    }
*/
namespace GqlPlus;
public class Model_Intro_Domain {}