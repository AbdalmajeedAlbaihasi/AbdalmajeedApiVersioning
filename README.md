# مشروع API Versioning

هذا التطبيق العملي لTask الـ API Versioning.

قسمت المشروع إلى 3 طبقات:
- DataAccess: تحتوي على نموذج البيانات كلاس Product وكلاس ProductDataAccess.
- Business: تحتوي على كلاس ProductBusiness لمنطق العمل واستدعاء البيانات.
- Api: تحتوي على الـ Controllers الخاصة بإصدارات V1 و V2، ومجلد الـ DTOs، وإعدادات Versioning و Swagger.

أهم النقاط التي عملت عليها:
- عمل إصدار V1 يرجع البيانات القديمة، وإصدار V2 يرجع البيانات مع CategoryName.
- فصلت الـ DTOs الخاصة بكل إصدار.
- اضفت Deprecated = true للإصدار الأول للتنبيه بإيقافه مستقبلاً.
