var SkillTreeSortableSample;
(function (SkillTreeSortableSample) {
    var Order;
    (function (Order) {
        Order[Order["Ascending"] = 0] = "Ascending";
        Order[Order["Descending"] = 1] = "Descending";
    })(Order || (Order = {}));
    var Sortable = (function () {
        function Sortable(container) {
            this.container = container;
            this.form = this.container.find("form");
            this.submit = this.container.find("[type=submit]");
            this.table = this.container.find(".sortable").parents("table");
            this.sortable = this.table.find("tr:first").find(".sortable");
            this.pager = this.container.find(".pagination-container");
            this.pageIndex = this.container.find("[name=page]");
            this.submitBefore();
            this.paginationClick();
            this.sorting();
        }
        /**
         * 排序事件綁定
         */
        Sortable.prototype.sorting = function () {
            var self = this;
            function nextSort(column, order) {
                self.container.find("[name=column]").val(column);
                self.container.find("[name=order]").val(order);
                self.submit.click();
            }
            ;
            this.sortable.click(function () {
                var current = $(this), icon = current.find("i"), column = current.data("column"), order = Order[current.data("direction")];
                switch (order) {
                    case Order.Ascending:
                        nextSort(column, Order[Order.Descending]);
                        icon.attr("class", "desc");
                        break;
                    case Order.Descending:
                        nextSort(column, Order[Order.Ascending]);
                        icon.attr("class", "asc");
                        break;
                    default:
                        nextSort(column, Order[Order.Ascending]);
                        icon.attr("class", "asc");
                }
                return false;
            });
        };
        /**
          * 按搜尋之前的處理
          * @returns {}
          */
        Sortable.prototype.submitBefore = function () {
            var self = this;
            self.submit.click(function () {
                self.pageIndex.val(1);
            });
        };
        /**
         * 綁定分頁列按下的行為
         */
        Sortable.prototype.paginationClick = function () {
            var self = this;
            self.pager.on("click", "a", function (e) {
                e.preventDefault();
                var current = $(this);
                var url = $.url(current.attr("href"));
                var page = parseInt(url.param("page"));
                if (isNaN(page))
                    return false;
                self.pageIndex.val(page);
                self.form.submit();
            });
        };
        return Sortable;
    }());
    SkillTreeSortableSample.Sortable = Sortable;
})(SkillTreeSortableSample || (SkillTreeSortableSample = {}));
//# sourceMappingURL=demoSortable.js.map